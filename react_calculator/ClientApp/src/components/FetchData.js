import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
      this.state = { expression : '' };
      this.Calculate = this.Calculate.bind(this);
  }

  componentDidMount() {
    this.populateWeatherData();
  }

    async Calculate() {
        debugger;
        const response = await fetch('weatherforecast', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({ example: this.state.expression })
        });
 
        const data = await response.json();
        this.setState({ expression: this.state.expression, solution: data.solution });
    }

    onExpressionChange(event) {
        this.setState({ expression: event.target.value })
    }
  renderForecastsTable(forecasts, calc) {
      return (
          <div>
              <h3>Введите ваше выражение:</h3>
              <input type="text" name="example" onChange={this.onExpressionChange.bind(this)} value={this.state.expression} />
              <button onClick={calc}>Enter</button>
              <h4>Результат: {this.state.solution}</h4>
          </div>
      //<table className='table table-striped' aria-labelledby="tabelLabel">
      //  <thead>
      //    <tr>
      //      <th>ID</th>
      //      <th>Expression</th>
      //      <th>Result</th>
      //      </tr>
      //  </thead>
      //  <tbody>
      //          {forecasts.map(forecast =>
      //              <tr key={forecast.id}>
      //                  <td>{forecast.id}</td>
      //                  <label>
      //                      Example:
      //                      <input type="text" name="example" value={this.example} />
      //                  </label>
      //                  <td>{forecast.solution}</td>
      //        <td>{forecast.result}</td>
      //        </tr>
      //    )}
      //  </tbody>
      //</table>
    );
  }

  render() {
    let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : this.renderForecastsTable(this.state.forecasts, this.Calculate.bind(this));

    return (
      <div>
        <h1 id="tabelLabel" >Calculator</h1>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('weatherforecast');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
