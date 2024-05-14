

import RefreshToken from "./RefreshToken";

const checkTokenExpirationAndRefresh = async () => {
    const TOKEN_EXPIRATION_DURATION = 5 * 60 * 1000;

    const accessTokenExpiration = localStorage.getItem("accessTokenExpiration");
    if (accessTokenExpiration) {
        const expirationTime = parseInt(accessTokenExpiration, 10);
        const currentTime = Date.now();
        if (expirationTime < currentTime) {
            const refreshToken = localStorage.getItem("refreshToken") || "";
            const { accessToken } = await RefreshToken({
                accessToken: localStorage.getItem("accessToken") || "",
                refreshToken
            });
            if (accessToken) {
                localStorage.setItem("accessToken", accessToken);
                localStorage.setItem("accessTokenExpiration", (currentTime + TOKEN_EXPIRATION_DURATION).toString());
            }
        }
    }
};


await checkTokenExpirationAndRefresh();
