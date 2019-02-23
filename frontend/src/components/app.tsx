import React, {Component} from 'react';
import AppBar from '@material-ui/core/AppBar';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Typography from '@material-ui/core/Typography';

import './app.css';

class App extends Component {
  render() {
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
                <Tabs value={0}>
                  <Tab label="Fizz Buzz with Purple Flamingo" />
                  <Tab label="Roman Calculator" />
                </Tabs>
              </AppBar>
              <h1>Here goes the content</h1>
            </Paper>
          </Grid>
        </Grid>
      </div>
    );
  }
}

export default App;
