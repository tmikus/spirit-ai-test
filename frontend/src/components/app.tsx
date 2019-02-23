import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Typography from '@material-ui/core/Typography';

import './app.css';
import FizzBuzz from "./fizz-buzz";
import RomanCalculator from "./roman-calculator";

interface AppProps {}

interface AppState {
  pageIndex: number;
}

class App extends React.PureComponent<AppProps, AppState> {
  state: AppState = {
    pageIndex: 0,
  };

  private handlePageChange = (event: React.ChangeEvent<{}>, value: number) => {
    this.setState((state) => ({
      ...state,
      pageIndex: value,
    }))
  };

  render() {
    const { pageIndex } = this.state;
    return (
      <div className="App">
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500"/>
        <Typography component="h1" variant="h1" gutterBottom align="center">
          Technical test
        </Typography>
        <Grid container justify="center" alignItems="center">
          <Grid item md={6}>
            <Paper>
              <AppBar position="static">
                <Tabs value={pageIndex} onChange={this.handlePageChange}>
                  <Tab label="Fizz Buzz with Purple Flamingo" value={0} />
                  <Tab label="Roman Calculator" value={1} />
                </Tabs>
              </AppBar>
              <div style={{ padding: 15 }}>
                {pageIndex === 0 && <FizzBuzz />}
                {pageIndex === 1 && <RomanCalculator />}
              </div>
            </Paper>
          </Grid>
        </Grid>
      </div>
    );
  }
}

export default App;
