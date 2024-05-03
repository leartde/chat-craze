import RefreshToken from "@/Services/UserServices/RefreshToken.ts";

const InitializeApp = async () => {
    const accessToken = localStorage.getItem("accessToken");
    const refreshToken = localStorage.getItem("refreshToken");

    if (accessToken && refreshToken) {
        try {
            const newAccessToken = await RefreshToken({accessToken, refreshToken});

            localStorage.setItem("accessToken", newAccessToken);
        } catch (error) {
            console.log("Token refresh failed:", error);
        }
    }
};

export default InitializeApp;