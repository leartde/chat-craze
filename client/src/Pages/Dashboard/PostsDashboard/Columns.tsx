import { ColumnDef } from "@tanstack/react-table";
import { ArrowUpDown, MoreHorizontal } from "lucide-react"
import { Button } from "@/Components/ui/button"
import {
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuSeparator,
    DropdownMenuTrigger,
} from "@/Components/ui/dropdown-menu";
import DeletePost from "@/Services/PostServices/DeletePost.ts";


// This type is used to define the shape of our data.
// You can use a Zod schema here if you want.
export type Post = {
    id: number;
    title: string;
    userName: string;
    likeCount: number;
    imageUrl : string;
}



export const columns: ColumnDef<Post>[] = [
    {
        accessorKey : "id",
        header: "Id",
        id: "id",
    },
    {
        accessorKey: "title",
        id: "title",
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Title
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },
    },
    {
        accessorKey: "userName",
        id: "userName",
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Author
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },

    },
    {
        accessorKey: "likeCount",
        id: "likeCount",
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Likes
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },

    },
    {
        id : "actions",
        cell : ({ row }) => {
            const post = row.original;
            return (
                <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                        <Button variant="ghost" className="h-8 w-8 p-0">
                            <span className="sr-only">Open menu</span>
                            <MoreHorizontal className="h-4 w-4" />
                        </Button>
                    </DropdownMenuTrigger>
                    <DropdownMenuContent align="end">
                        <DropdownMenuLabel>Actions</DropdownMenuLabel>
                        <DropdownMenuItem
                            onClick={() => navigator.clipboard.writeText(post.id.toString())}
                        >
                            Copy Post ID
                        </DropdownMenuItem>
                        <DropdownMenuSeparator />
                        <DropdownMenuItem>View Post Details</DropdownMenuItem>
                        <DropdownMenuItem>Edit Post details</DropdownMenuItem>
                        <DropdownMenuItem  className="text-red-600 hover:!bg-red-600 hover:!text-white" onClick={()=> DeletePost(post.id)}> Delete Post </DropdownMenuItem>
                    </DropdownMenuContent>
                </DropdownMenu>
            )
        },

    },

]
