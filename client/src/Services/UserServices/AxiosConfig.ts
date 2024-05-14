

import axios, { AxiosRequestConfig } from "axios";
import RefreshToken from "./RefreshToken";

axios.interceptors.response.use(
    response => response,
    async error => {
        const originalRequest = error.config as AxiosRequestConfig & { _retry?: boolean };

        if (error.response && error.response.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;
            const { accessToken } = await RefreshToken({
                accessToken: localStorage.getItem("accessToken") || "",
                refreshToken: localStorage.getItem("refreshToken") || ""
            });
            if (accessToken) {
                originalRequest.headers = {
                    ...originalRequest.headers,
                    Authorization: `Bearer ${accessToken}`
                };
                return axios(originalRequest);
            }
        }
        return Promise.reject(error);
    }
);

export default axios;
