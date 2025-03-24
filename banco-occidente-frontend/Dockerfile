FROM node:18-alpine AS build

WORKDIR /app

COPY . .

RUN npm install && npm run build

FROM node:18-alpine AS runtime
WORKDIR /app

COPY --from=build /app/.output ./

EXPOSE 3000

ENV NUXT_PUBLIC_API_BASE_URL=http://localhost:5020/api

CMD ["node", "server/index.mjs"]
