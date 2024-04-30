import React from 'react';
import { useDispatch } from "react-redux";
import { Input } from "@/Components/ui/input.tsx";
import { setSearchTerm } from '@/State/PostParameters/PostParametersSlice';


const SearchTerm = () => {
    const [searchTerm, setSearchTermLocal] = React.useState<string>("");
    const dispatch = useDispatch();

    const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const newValue = e.target.value;
        setSearchTermLocal(newValue);
        dispatch(setSearchTerm(newValue));
    }

    return (
        <div className="w-64 ">
            <Input
                className="!bg-secondary"
                value={searchTerm}
                onChange={handleSearchChange}
                placeholder="Search for a post..."
            />
        </div>
    );
};

export default SearchTerm;
