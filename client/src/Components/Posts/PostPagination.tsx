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
    const pageNumber = useSelector((state: RootState) => state.postParameters.pageNumber);
    const totalPages = useSelector((state: RootState) => state.postParameters.totalPages);
    const pageNumbers = Array.from({ length: totalPages }, (_, i) => i + 1);
    const handlePageChange = (pageNumber: number) => {
        console.log("Page number clicked: ", pageNumber)
        dispatch(setPageNumber(pageNumber));
    }

    return (
        <div className="mt-12 w-1/3 mx-auto rounded-xl">
            <Pagination>
                <PaginationContent className="text-secondary ">
                    <PaginationItem className="bg-primary rounded-xl" >
                        <PaginationPrevious className={`${pageNumber === 1?"hidden":""} cursor-pointer`} onClick={()=>handlePageChange(pageNumber - 1)} href="#" />
                    </PaginationItem>
                    {pageNumbers.map((pageNumber) => (
                        <PaginationItem className="bg-primary rounded-xl" key={pageNumber}>
                            <PaginationLink className="cursor-pointer" onClick={()=>handlePageChange(pageNumber)}>{pageNumber}</PaginationLink>
                        </PaginationItem>
                    ))}
                    <PaginationItem className="bg-primary rounded-xl">
                        <PaginationNext   className={`${pageNumber === totalPages && totalPages != 0?"hidden":""} cursor-pointer`} onClick={()=>handlePageChange(pageNumber + 1)} href="#" />
                    </PaginationItem>
                </PaginationContent>
            </Pagination>
        </div>
    );
};

export default PostPagination;
