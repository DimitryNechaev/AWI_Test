import Settings from "../settings";

export default class GlossaryService {
    private url: string;

    constructor() {
        this.url = Settings.apiUrl;
    }

    public async getAll(): Promise<GlossaryModel.IGlossaryRecord[]> {
        try {
            const response = await fetch(this.url + "Glossary/List");
            const json = await response.json();
            return json;
        }
        catch (e) {
            return [];
        }
    }

    public async Create(model: GlossaryModel.IGlossaryRecord) : Promise<any>
    {
        try {
            const response = await fetch(this.url + "Glossary/Create", {
                method: 'POST',
                body: JSON.stringify(model),
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                }
            });
            await response.json();
        }
        catch (e) {
            return [];
        }
    }

    public async Update(term: string, model: GlossaryModel.IGlossaryRecord) : Promise<any>
    {
        try {
            const response = await fetch(this.url + "Glossary/Update?term=" + term, {
                method: 'PUT',
                body: JSON.stringify(model),
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                }
            });
            await response.json();
        }
        catch (e) {
            return [];
        }
    }

    public async Delete(term: string) : Promise<any>
    {
        try {
            const response = await fetch(this.url + "Glossary/Delete?term=" + term, {
                method: 'DELETE'
            });
            await response.json();
        }
        catch (e) {
            return [];
        }
    }

}