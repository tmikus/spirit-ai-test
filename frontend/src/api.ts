const URL = "http://localhost:8081/api";

export function doFizzBuzz(count: number): Promise<Array<string>> {
  return fetch(`${URL}/fizzbuzzpinkflamingo/${count}`)
    .then((res) => res.json())
    .then((body) => body.lines);
}