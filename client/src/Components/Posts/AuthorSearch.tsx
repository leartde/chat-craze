import React from 'react';
import { useDispatch } from "react-redux";
import { Input } from "@/Components/ui/input.tsx";
import {setAuthor} from '@/State/PostParameters/PostParametersSlice';


const AuthorSearch = () => {
    const [searchTerm, setSearchTermLocal] = React.useState<string>("");
    const dispatch = useDispatch();

    const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const newValue = e.target.value;
        setSearchTermLocal(newValue);
        dispatch(setAuthor(newValue));
    }

    return (
        <div className="w-64">
            <Input
                value={searchTerm}
                onChange={handleSearchChange}
                placeholder="Search for an author..."
            />
        </div>
    );
};

export default AuthorSearch;