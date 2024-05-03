import React, { useState} from 'react';
import {useDispatch} from "react-redux";
import {setMinLikes} from "@/State/PostParameters/PostParametersSlice.ts";

const LikeSlider = () => {
    const [minimumLikes, setMinimumLikes] = useState<number>(0);

    const dispatch = useDispatch();

    const handleMinLikesChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = parseInt(e.target.value);
        setMinimumLikes(value);
        dispatch(setMinLikes(value));
    };
    return (
        <div className="w-64 justify-start   lg:flex flex-col">
            <label htmlFor="myRange" className="text-secondary font-semibold">Minimum likes: {minimumLikes}</label>
            <input onChange={handleMinLikesChange} type="range" min="0" max="25"
                   className="  bg-gray-400 text-red-600 rounded-full focus:outline-none appearance-none" id="myRange"/>
        </div>
    );
};

export default LikeSlider;
