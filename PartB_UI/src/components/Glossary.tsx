import * as React from 'react';
import GlossaryService from '../services/GlossaryService';
import GlossaryRow from "../components/GlossaryRow";
import { Row, Col, Button } from 'reactstrap';

interface IGlossaryState {
  records: GlossaryModel.IGlossaryRecord[];
}

class Glossary extends React.Component<any, IGlossaryState> {
  public state: IGlossaryState = {
    records: []
  }

  componentDidMount() {
      this.refresh();
  }

  callApi = async () => {
    const repo = new GlossaryService();
    const data = await repo.getAll();
    return data;
  };

  refresh = async() => {
    this.setState({ records: [] });
    this.callApi()
      .then(data => this.setState({ records: data }))
      // tslint:disable-next-line:no-console
      .catch(err => console.log(err));
  }

  handleAddClick() : void {
    let newRecords = this.state.records;
    newRecords.push({
      term: "",
      definition: ""
    });
    this.setState({ records: newRecords });
  }

  public render() {
    return (
        <div className="container-fluid">
          <Row className="bg-info">
              <Col xs="3" sm="3" md="3">Term</Col>
              <Col xs="7" sm="7" md="7">Definition</Col>    
              <div className="col-2 col-sm-2 col-md-2"><div className="btn-group">
                      <button type="button" className="btn btn-primary btn-sm" onClick={ e => this.handleAddClick() }>Add</button>
                  </div>
              </div>              
          </Row>

          {this.state.records.map((record, idx) => {
              return (
                <GlossaryRow key={record.term} record={record}/>
              )
            })}
                    
          <Row>
            <Col>
              <Button className="btn btn-info btn-lg btn-block" onClick={this.refresh}>Refresh</Button>
            </Col>
          </Row>
        </div>
      ) 
  }
}

export default Glossary;
