import React from 'react';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import TextField from '@material-ui/core/TextField';
import Typography from '@material-ui/core/Typography';
import {doFizzBuzz, romanCalculator} from "../api";

interface RomanCalculatorProps {}

interface RomanCalculatorState {
  expression: string;
  result: string;
}

export default class RomanCalculator extends React.PureComponent<RomanCalculatorProps, RomanCalculatorState> {
  state: RomanCalculatorState = {
    expression: '',
    result: '',
  };

  private handleCalculatePress = () => {
    romanCalculator(this.state.expression).then((result) => {
      this.setState((state) => ({
        ...state,
        result,
      }));
    });
  };

  private handleExpressionChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const expression = e.currentTarget.value;
    this.setState((state) => ({
      ...state,
      expression,
    }));
  };

  render() {
    const { expression, result } = this.state;
    return (
      <Grid container spacing={16}>
        <Grid item md={8}>
          <Grid
            container
            direction="column"
            spacing={16}
          >
            <Grid item >
              <TextField
                fullWidth
                onChange={this.handleExpressionChange}
                placeholder="Expression"
                required
                value={expression}
              />
            </Grid>
            <Grid item xs={12}>
              <Button
                color="primary"
                onClick={this.handleCalculatePress}
                variant="contained"
              >
                Calculate
              </Button>
            </Grid>
          </Grid>
        </Grid>
        <Grid item md={4} alignContent="center">
          <Typography component="h2" gutterBottom variant="h5">= {result}</Typography>
        </Grid>
      </Grid>
    )
  }
}
