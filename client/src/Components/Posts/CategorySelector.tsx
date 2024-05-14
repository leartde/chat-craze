import {CATEGORIES} from "@/Constants";
import {Button} from "@/Components/ui/button.tsx";
import {useDispatch, useSelector} from "react-redux";
import {setCategory, setPageNumber} from "@/State/PostParameters/PostParametersSlice.ts";
import {RootState} from "@/State/Store.ts";
import {
    DropdownMenu,
    DropdownMenuCheckboxItem,
    DropdownMenuContent,
    DropdownMenuLabel,
} from '../ui/dropdown-menu';
import {DropdownMenuTrigger} from "@/Components/ui/dropdown-menu.tsx";

const CategorySelector = () => {
    const categories : string[] = CATEGORIES;
        const dispatch = useDispatch();
    const handleCategoryClick = (category: string) => {
            dispatch(setCategory(category));
            dispatch(setPageNumber(1));
    }

    const selectedCategory = useSelector((state: RootState) => state.postParameters.category);return (
        <div className="w-64 justify-start bg-secondary  lg:flex flex-col  ">
            <DropdownMenu>
                <DropdownMenuTrigger asChild>
                    <Button  className="font-semibold text-base" variant="outline">{selectedCategory==""?"Categories":selectedCategory}</Button>
                </DropdownMenuTrigger>
                <DropdownMenuContent className="w-56 !bg-secondary ">
                    <DropdownMenuCheckboxItem className="cursor-pointer hover:!bg-primary hover:!text-secondary" onClick={()=>handleCategoryClick("")}>
                        <DropdownMenuLabel>All</DropdownMenuLabel>
                    </DropdownMenuCheckboxItem>
                    {
                        categories.map((category) => (
                            <DropdownMenuCheckboxItem
                                className="cursor-pointer  hover:!bg-primary hover:!text-secondary"
                                key={category}
                                checked={category === selectedCategory}
                                onClick={() => handleCategoryClick(category)}
                            >
                                <DropdownMenuLabel >{category}</DropdownMenuLabel>
                            </DropdownMenuCheckboxItem>
                        )
                        )
                    }
                </DropdownMenuContent>
            </DropdownMenu>


        </div>
    );
};

export default CategorySelector;
