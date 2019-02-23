import React from 'react';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import TextField from '@material-ui/core/TextField';
import Typography from '@material-ui/core/Typography';
import {doFizzBuzz} from "../api";

interface FizzBuzzProps {}

interface FizzBuzzState {
  countTo: number;
  results: Array<string> | undefined;
}

export default class FizzBuzz extends React.PureComponent<FizzBuzzProps, FizzBuzzState> {
  state: FizzBuzzState = {
    countTo: 15,
    results: undefined,
  };

  private handleCountPress = () => {
    doFizzBuzz(this.state.countTo).then((results) => {
      this.setState((state) => ({
        ...state,
        results,
      }));
    })
  };

  private handleCountToChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = parseInt(e.currentTarget.value);
    this.setState((state) => ({
      ...state,
      countTo: value,
    }));
  };

  render() {
    const { countTo, results } = this.state;
    return (
      <Grid container>
        <Grid item md={4}>
          <Grid
            container
            direction="column"
            alignItems="center"
            spacing={16}
          >
            <Grid item>
              <TextField
                onChange={this.handleCountToChange}
                placeholder="What number to count to?"
                required
                type="number"
                value={countTo}
              />
            </Grid>
            <Grid item>
              <Button
                color="primary"
                onClick={this.handleCountPress}
                variant="contained"
              >
                Count!
              </Button>
            </Grid>
          </Grid>
        </Grid>
        <Grid item md={8} alignContent="center">
          <Typography align="center" component="h2" gutterBottom variant="h5">Results</Typography>
          {typeof results === "undefined" && (
            <Typography align="center" variant="body1">Nothing here. Hit "Count" to get started</Typography>
          )}
          {results && (
            <ul>
              {results.map((line) => <li>{line}</li>)}
            </ul>
          )}
        </Grid>
      </Grid>
    )
  }
}
