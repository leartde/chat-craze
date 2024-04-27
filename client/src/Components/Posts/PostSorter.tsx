import React, {useState} from 'react';
import {
    DropdownMenu,
    DropdownMenuCheckboxItem,
    DropdownMenuContent,
    DropdownMenuLabel,
} from '../ui/dropdown-menu';
import {DropdownMenuTrigger} from "@/Components/ui/dropdown-menu.tsx";
import {Button} from "@/Components/ui/button.tsx";
import {useDispatch} from "react-redux";
import {setOrderBy} from "@/State/PostParameters/PostParametersSlice.ts";
const PostSorter = () => {
    const dispatch = useDispatch();
    const [selectedSort, setSelectedSort] = useState<string>("Most Recent")
    const handleSort = (sort: string) => {
        dispatch(setOrderBy(sort));
    }
    return (
        <div className="w-64 justify-start  lg:flex flex-col">
            <DropdownMenu>
                <DropdownMenuTrigger asChild >
                    <Button variant="outline" className="font-semibold text-base">Sort by : {selectedSort}</Button>
                </DropdownMenuTrigger>
                <DropdownMenuContent className="w-56 !bg-primary">
                    <DropdownMenuCheckboxItem onClick={()=>{
                        handleSort("createdAt desc");
                        setSelectedSort("Most recent");
                    }} className="cursor-pointer hover:!bg-cyan-800">
                        <DropdownMenuLabel>Most recent</DropdownMenuLabel>
                    </DropdownMenuCheckboxItem>


                    <DropdownMenuCheckboxItem onClick={()=>{
                        handleSort("likeCount desc");
                        setSelectedSort("Most popular");
                    }} className="cursor-pointer hover:!bg-cyan-800">
                        <DropdownMenuLabel className="cursor-pointer">Most popular</DropdownMenuLabel>
                    </DropdownMenuCheckboxItem>

                    <DropdownMenuCheckboxItem onClick={()=>{
                        handleSort("createdAt");
                        setSelectedSort("Oldest");
                    }} className="cursor-pointer hover:!bg-cyan-800">
                        <DropdownMenuLabel >Oldest</DropdownMenuLabel>
                    </DropdownMenuCheckboxItem>

                </DropdownMenuContent>



            </DropdownMenu>
        </div>
    );
};

export default PostSorter;
