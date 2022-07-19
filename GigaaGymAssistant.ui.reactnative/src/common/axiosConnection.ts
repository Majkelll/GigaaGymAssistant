import axios, { AxiosError } from "axios";

export const api = axios.create({
  baseURL: "https://localhost:7171/api/",
  withCredentials: true,
});

api.interceptors.request.use((request) => {
  return request;
});

api.interceptors.response.use(
  (response) => {
    return response;
  },
  (error: AxiosError) => {}
);
