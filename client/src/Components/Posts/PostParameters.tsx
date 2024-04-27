
import SearchTerm from "@/Components/Posts/SearchTerm.tsx";
import CategorySelector from "@/Components/Posts/CategorySelector.tsx";
import AuthorSearch from "@/Components/Posts/AuthorSearch.tsx";
import PostSorter from "@/Components/Posts/PostSorter.tsx";

const PostParameters = () => {
    return (
        <div className="w-1/5 bg-primary rounded-xl h-[40vh] hidden gap-6 py-8 rounded-lg  lg:flex flex-col border border-black  items-center flex-wrap ">
            <h2 className="text-2xl text-secondary font-semibold">Filter the posts</h2>
            <SearchTerm/>
            <AuthorSearch/>
            <CategorySelector/>
            <PostSorter/>
            
        </div>
    );
};

export default PostParameters;
