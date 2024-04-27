import {configureStore} from "@reduxjs/toolkit";
import UserClaimsReducer from "./UserClaims/UserClaimsSlice";
import PostParametersReducer from "./PostParameters/PostParametersSlice";
export const Store = configureStore({
    reducer : {
        userClaims: UserClaimsReducer,
        postParameters: PostParametersReducer
    }

});

export type RootState = ReturnType<typeof Store.getState>;
export type AppDispatch = typeof Store.dispatch;
