# Spirit AI Technical Test

## Technologies used

### Frontend

- React
- Webpack (build)
- Jest (testing)

### Backend

- ASP.NET Core 2.2
- Nunit (testing)


## Tasks

1. [X] Implement FizzBuzz
2. [X] Extend the FizzBuzz with ability to print Pink Flamingo
3. [X] Roman numeral converter
    - [X] Decimal to roman
    - [X] Roman to decimal
4. [X] Implement a roman numerals calculator
    - [X] Addition
    - [X] Subtraction
    - [X] Multiplication
    - [X] Division
    - [X] Power
    - [X] Brackets
5. [X] Expose the above features in a Web API
6. [ ] Build a nice frontend
7. [ ] Dockerise both frontend and backend
8. [ ] SHIP IT!

## Running project

To run the dockerised version you need a fairly new version of Docker.
The following instructions expect you to run the project on a pre-defined port, as it is going to be used for communication between front-end and the backend.

1. Navigate to `backend` folder and build project's docker image:
    ```bash
    docker build -t api .
    ```
2. Run the API on port 8080
    ```bash
    docker run -d -p 8081:80 --name api-instance api
    ```
    
// TODO: Add the instruction on how to start the frontend
    
## Final thoughts

Nice idea for a project, guys! I like the fact that I could build primitive interpreter at the end :)
Hope you like my solution. 