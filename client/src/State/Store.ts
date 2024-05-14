import { configureStore } from "@reduxjs/toolkit";
import UserClaimsReducer from "./UserClaims/UserClaimsSlice";
import PostParametersReducer from "./PostParameters/PostParametersSlice";
import { persistStore, persistReducer } from 'redux-persist';
import storage from "redux-persist/lib/storage";

const persistConfig = {
    key: 'root',
    storage,
};
const persistedUserClaimsReducer = persistReducer(persistConfig, UserClaimsReducer);

export const Store = configureStore({
    reducer: {
        userClaims: persistedUserClaimsReducer,
        postParameters: PostParametersReducer
    }
});

export const persistedStore = persistStore(Store);

export type RootState = ReturnType<typeof Store.getState>;
export type AppDispatch = typeof Store.dispatch;
