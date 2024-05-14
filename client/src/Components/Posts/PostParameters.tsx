
import SearchTerm from "@/Components/Posts/SearchTerm.tsx";
import CategorySelector from "@/Components/Posts/CategorySelector.tsx";
import AuthorSearch from "@/Components/Posts/AuthorSearch.tsx";
import PostSorter from "@/Components/Posts/PostSorter.tsx";
import LikeSlider from "@/Components/Posts/LikeSlider.tsx";

const PostParameters = () => {
    return (
        <div className="w-1/5 shrink bg-primary rounded-xl h-1/2 max-2xl:hidden p-4 gap-8 flex-wrap justify-center   flex flex-col border border-black  items-center ">
            <h2 className="text-2xl text-secondary text-center font-semibold">Filter the posts</h2>
            <SearchTerm/>
            <AuthorSearch/>
            <CategorySelector/>
            <PostSorter/>
            <LikeSlider/>
            
        </div>
    );
};

export default PostParameters;
