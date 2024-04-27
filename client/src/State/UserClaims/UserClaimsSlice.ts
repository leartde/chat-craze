import {createSlice, PayloadAction} from "@reduxjs/toolkit";

type UserClaimsState = {
    username: string,
    email: string,
    id: string,
    avatarUrl: string,
    role: string
};

const initialState: UserClaimsState = {
    username: "",
    email: "",
    id: "",
    avatarUrl: "",
    role: ""
};

const UserClaimsSlice = createSlice({
    name: "userClaims",
    initialState,
    reducers: {
        setUserClaims: (state, action: PayloadAction<UserClaimsState>) => {
            state.username = action.payload.username;
            state.email = action.payload.email;
            state.id = action.payload.id;
            state.avatarUrl = action.payload.avatarUrl;
            state.role = action.payload.role;
        },
        clearUserClaims: (state) => {
            state.username = "";
            state.email = "";
            state.id = "";
            state.avatarUrl = "";
            state.role = "";
        }
    }
});
export const {setUserClaims, clearUserClaims} = UserClaimsSlice.actions;
export default UserClaimsSlice.reducer;