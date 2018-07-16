import * as React from 'react';
import GlossaryService from '../services/GlossaryService';

interface IGlossaryRowProps {
    record: GlossaryModel.IGlossaryRecord;
}

interface IGlossaryRowState extends IGlossaryRowProps {
    editing: boolean;
    id: string;
}

class GlossaryRow extends React.Component<IGlossaryRowProps, IGlossaryRowState> {
    constructor(props: IGlossaryRowProps){
        super(props);
        this.state = {
            editing: props.record.term === "",
            id: props.record.term,
            record: {
                term: props.record.term,
                definition: props.record.definition
            }
        }
    }

    public handleOnClick() : void {
        this.setState({ 
            editing: true,
            record: this.state.record
         });
    }

    handleOnChangeTerm(e: React.ChangeEvent) {
        this.setState({ 
            editing: true,
            record: {
                term: (e.target as HTMLInputElement).value,
                definition: this.state.record.definition
            }
         });
    }

    handleOnChangeDefinition(e: React.ChangeEvent) {
        this.setState({ 
            editing: true,
            record: {
                term: this.state.record.term,
                definition: (e.target as HTMLInputElement).value
            }
         });
    }

    handleCancelClick() : void {
        this.setState({ 
            editing: false,
            record: this.props.record
         });
    }

    handleSaveClick() : void {
        const repo = new GlossaryService();

        let prom: Promise<any>;
        
        if (this.state.id)
            prom = repo.Update(this.state.id, this.state.record);
        else
            prom = repo.Create(this.state.record);

        prom.then(() => {
            this.setState({ 
                editing: false,
                record: this.state.record,
                id: this.state.record.term
            });
        });
    }

    handleDeleteClick() : void {
        const repo = new GlossaryService();
        repo.Delete(this.state.id)
        .then(() => {
                // do not cascade deletion up, just hide the deleted row
                this.setState({ 
                    editing: false,
                    record: null as any
                });
            }        
        );       
    }

    public render() {
        if (this.state.record == null)
        {
            return;
        }
        else if (this.state.editing) {
            return (
                <div className="row">
                    <div className="col-3 col-sm-3 col-md-3"><input type="text" className="form-control" onChange={ e => this.handleOnChangeTerm(e) } value={this.state.record.term} /></div>
                    <div className="col-7 col-sm-7 col-md-7"><input type="text" className="form-control" onChange={ e => this.handleOnChangeDefinition(e) } value={this.state.record.definition} /></div>    
                    <div className="col-2 col-sm-2 col-md-2"><div className="btn-group">
                            <button type="button" className="btn btn-primary btn-sm" onClick={ e=> this.handleSaveClick() }>Save</button>
                            <button type="button" className="btn btn-primary btn-sm" onClick={ e=> this.handleCancelClick() }>Cancel</button>
                        </div>
                    </div>
                </div>
            )
        }
        else {
            return (
                <div className="row">               
                    <div className="col-3 col-sm-3 col-md-3" onClick={ e=> this.handleOnClick() }>{this.state.record.term}</div>
                    <div className="col-7 col-sm-7 col-md-7" onClick={ e=> this.handleOnClick() }>{this.state.record.definition}</div>    
                    <div className="col-2 col-sm-2 col-md-2"><div className="btn-group">
                            <button type="button" className="btn btn-primary btn-sm" onClick={ e=> this.handleDeleteClick() }>Delete</button>
                        </div>
                    </div>
                </div>
            )
        }

    }
}

export default GlossaryRow;