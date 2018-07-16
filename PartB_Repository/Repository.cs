using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PartB_RepositoryAbstraction;
using Newtonsoft.Json;

namespace PartB_Repository
{
    public class Repository: IRepository
    {
        private readonly string _csvFilename;

        public Repository(string csvFileName)
        {
            _csvFilename = csvFileName;
        }

        private List<TermModel> ReadFile()
        {
            var content = File.ReadAllText(_csvFilename);
            return JsonConvert.DeserializeObject<List<TermModel>>(content);
        }

        private void WriteFile(List<TermModel> list)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(_csvFilename, json);
        }

        delegate void UpdateListAction(List<TermModel> list);
        private void UpdateList(UpdateListAction action)
        {
            var list = ReadFile();
            action(list);
            WriteFile(list);
        }

        public IEnumerable<TermModel> GetSortedList()
        {
            var list = ReadFile();
            return list.OrderBy(item => item.Term);
        }

        public void AddTerm(TermModel model)
        {
            UpdateList(list => list.Add(model));
        }

        public void UpdateTerm(string oldTerm, TermModel model)
        {
            UpdateList(list =>
            {
                var entry = list.FirstOrDefault(item => item.Term == oldTerm);
                if (entry != null)
                {
                    entry.Term = model.Term;
                    entry.Definition = model.Definition;
                }
            });
        }

        public void DeleteTerm(string term)
        {
            UpdateList(list =>
            {
                var entry = list.FirstOrDefault(item => item.Term == term);
                if (entry != null)
                    list.Remove(entry);
            });
        }
    }
}
