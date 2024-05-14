import {createSlice, PayloadAction} from "@reduxjs/toolkit";

type PostParametersSlice = {
    category: string;
    author: string;
    searchTerm : string;
    pageNumber: number;
    pageSize: number;
    orderBy: string;
    totalPages : number;
    minLikes : number;
    hasNext : boolean;
    hasPrevious : boolean;
    currentPage : number;
}

const initialState: PostParametersSlice = {
    category: "",
    author: "",
    searchTerm: "",
    pageNumber: 1,
    pageSize: 10,
    orderBy: "createdAt",
    totalPages: 0,
    minLikes: 0,
    hasNext: false,
    hasPrevious: false,
    currentPage : 1

};

const PostParametersSlice = createSlice({
    name: "postParameters",
    initialState,
    reducers: {
        setCategory: (state, action: PayloadAction<string>) => {
            state.category = action.payload;
        },
        setAuthor: (state, action: PayloadAction<string>) => {
            state.author = action.payload;
        },
        setSearchTerm: (state, action: PayloadAction<string>) => {
            state.searchTerm = action.payload;
        },
        setPageNumber: (state, action: PayloadAction<number>) => {
            state.pageNumber = action.payload;
        },
        setPageSize: (state, action: PayloadAction<number>) => {
            state.pageSize = action.payload;
        },
        setOrderBy: (state, action: PayloadAction<string>) => {
            state.orderBy = action.payload;
        },
        setTotalPages: (state, action: PayloadAction<number>) => {
            state.totalPages = action.payload;
        },
        setMinLikes: (state, action: PayloadAction<number>) => {
            state.minLikes = action.payload;
        },
        setHasNext: (state, action: PayloadAction<boolean>) => {
            state.hasNext = action.payload;
        },
        setHasPrevious: (state, action: PayloadAction<boolean>) => {
            state.hasPrevious = action.payload;
        },
        setCurrentPage: (state, action: PayloadAction<number>) => {
            state.currentPage = action.payload;
        }
    }
})

export const setCategory = PostParametersSlice.actions.setCategory;
export const setSearchTerm = PostParametersSlice.actions.setSearchTerm;
export const setPageNumber = PostParametersSlice.actions.setPageNumber;
export const setPageSize = PostParametersSlice.actions.setPageSize;
export const setOrderBy = PostParametersSlice.actions.setOrderBy;
export const setAuthor = PostParametersSlice.actions.setAuthor;
export const setTotalPages = PostParametersSlice.actions.setTotalPages;
export const setMinLikes = PostParametersSlice.actions.setMinLikes;
export const setHasNext = PostParametersSlice.actions.setHasNext;
export const setHasPrevious = PostParametersSlice.actions.setHasPrevious;
export const setCurrentPage = PostParametersSlice.actions.setPageNumber;
export default PostParametersSlice.reducer;