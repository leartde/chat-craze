import React from 'react';
import {
    Pagination,
    PaginationContent,
    PaginationEllipsis,
    PaginationItem,
    PaginationLink,
    PaginationNext,
    PaginationPrevious,
} from "@/Components/ui/pagination";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "@/State/Store.ts";
import {setPageNumber} from "@/State/PostParameters/PostParametersSlice.ts";

const PostPagination = () => {
    const dispatch = useDispatch();
    const currentPage = useSelector((state: RootState) => state.postParameters.pageNumber);
    const totalPages = useSelector((state: RootState) => state.postParameters.totalPages);
    const pageNumbers = Array.from({ length: totalPages }, (_, i) => i + 1);
    const hasNext : boolean = useSelector((state: RootState) => state.postParameters.hasNext);
    const hasPrevious : boolean = useSelector((state: RootState) => state.postParameters.hasPrevious);
    const handlePageChange = (currentPage: number) => {
        console.log("Page number clicked: ", currentPage)
        dispatch(setPageNumber(currentPage));
    }

    return (
        <div className="mt-12 w-1/3 mx-auto rounded-xl">
            <Pagination>
                <PaginationContent className="text-secondary ">
                    {
                        hasPrevious &&  <PaginationItem className="bg-primary rounded-xl" >
                            <PaginationPrevious className="cursor-pointer" onClick={()=>handlePageChange(currentPage - 1)} href="#" />
                        </PaginationItem>
                    }
                    {pageNumbers.map((page) => (
                        <PaginationItem className={` ${currentPage==page?'bg-gray-400':'bg-primary'} rounded-xl`} key={page}>
                            <PaginationLink className="cursor-pointer" onClick={()=>handlePageChange(page)}>{page}</PaginationLink>
                        </PaginationItem>
                    ))}
                    {hasNext &&  <PaginationItem className="bg-primary rounded-xl">
                        <PaginationNext   className= "cursor-pointer" onClick={()=>handlePageChange(currentPage + 1)} href="#" />
                    </PaginationItem>}
                        </PaginationContent>
            </Pagination>
        </div>
    );
};

export default PostPagination;
