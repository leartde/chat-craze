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
            console.log("Response URL:", url);

            // Parse the JSON string from the x-pagination header
            const totalPagesHeader = response.headers['x-pagination'];
            const parsedHeader = JSON.parse(totalPagesHeader);
            const totalPages = parsedHeader.TotalPages;
            const posts: Post[] = response.data;

            return {
                data: posts,
                totalPages: totalPages
            };
        } else {
            console.log("Error fetching posts: ", response.statusText);
        }
    } catch (e) {
        console.log("Caught exception while trying to fetching posts: ", e);
    }
}

export default FetchPosts;
