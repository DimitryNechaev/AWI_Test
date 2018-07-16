using System;
using System.Collections;
using System.Collections.Generic;

namespace PartB_RepositoryAbstraction
{
    public interface IRepository
    {
        IEnumerable<TermModel> GetSortedList();
        void AddTerm(TermModel model);
        void UpdateTerm(string oldTerm, TermModel model);
        void DeleteTerm(string term);
    }
}
