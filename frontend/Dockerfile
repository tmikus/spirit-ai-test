FROM node:11 AS build-env

WORKDIR /app

# Copy everything and build
COPY . ./
RUN npm install
RUN npm run build

# Build runtime image
FROM nginx

WORKDIR /usr/share/nginx/html
COPY --from=build-env /app/build .