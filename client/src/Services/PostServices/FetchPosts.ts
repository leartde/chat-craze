import axios from "axios";
import { Post } from "@/Pages/Posts/PostGrid.tsx";

type PostParameters = {
    category?: string;
    author?: string;
    pageSize: number;
    pageNumber: number;
    searchTerm?: string;
    orderBy?: string ;
    minLikes?: number;
}

type Headers = {
    TotalPages: number;
    hasNext: boolean;
    hasPrevious: boolean;
    PageSize: number;
    CurrentPage: number;

}

const FetchPosts = async ({minLikes, category, author, pageSize, pageNumber, searchTerm, orderBy }: PostParameters) => {
    try {
        let url = `http://localhost:5002/api/posts?PageSize=${pageSize}`;
        if (category && category.trim() !== "") {
            url += `&Category=${encodeURIComponent(category)}`;
        }
        if (searchTerm && searchTerm.trim() !== "") {
            url += `&SearchTerm=${encodeURIComponent(searchTerm)}`;
        }
        if(pageNumber && pageNumber > 0){
            url += `&PageNumber=${pageNumber}`;
        }
        if(author && author.trim() !== ""){
            url += `&UserName=${encodeURIComponent(author)}`;
        }
        if(orderBy && orderBy.trim() !== ""){
            url += `&OrderBy=${encodeURIComponent(orderBy)}`;
        }
        if(minLikes && minLikes > 0){
            url += `&MinLikes=${minLikes}`;
        }

        const response = await axios.get(url);

        if (response.status === 200) {
            // console.log("Response URL:", url);
            const headers = response.headers['x-pagination'];
            const parsedHeader : Headers = JSON.parse(headers);
            const totalPages = parsedHeader.TotalPages;
            const hasNext = parsedHeader.hasNext;
            const hasPrevious = parsedHeader.hasPrevious;
            const currentPage = parsedHeader.CurrentPage;

            const posts: Post[] = response.data;

            return {
                data: posts,
                totalPages: totalPages,
                hasNext: hasNext,
                hasPrevious: hasPrevious,
                currentPage: currentPage
            };
        } else {
            console.log("Error fetching posts: ", response.statusText);
        }
    } catch (e) {
        console.log("Caught exception while trying to fetching posts: ", e);
    }
}

export default FetchPosts;
