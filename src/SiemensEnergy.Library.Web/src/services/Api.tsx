import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7259"
});

export { api };