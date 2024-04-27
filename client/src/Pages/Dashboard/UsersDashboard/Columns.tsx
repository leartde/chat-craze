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
import DeleteUser from "@/Services/UserServices/DeleteUser.ts";
import {Dialog, DialogFooter} from "@/Components/ui/dialog";
import {DialogContent, DialogDescription, DialogHeader, DialogTitle, DialogTrigger} from "@/Components/ui/dialog.tsx";
import {Input} from "@/Components/ui/input.tsx";
import {Label} from "@/Components/ui/label.tsx";
import UpdateUserCard from "@/Components/Users/UpdateUserCard.tsx";
import {ToastContainer} from "react-toastify";
import DeleteUserCard from "@/Components/Users/DeleteUserCard.tsx";


// This type is used to define the shape of our data.
// You can use a Zod schema here if you want.
export type User = {
    id: string;
    userName: string;
    email: string;
}

export const columns: ColumnDef<User>[] = [

    {
        accessorKey : "id",
        header: "Id",
    },
    {
        accessorKey: "userName",
        id:"userName",
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Username
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },
    },
    {
        accessorKey: "email",
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Email
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },

    },
    {
        accessorKey: "role",
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Role
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },

    },
    {
        id : "actions",
        cell : ({ row }) => {
            const user: User = row.original;
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
                            onClick={() => navigator.clipboard.writeText(user.id)}
                        >
                            Copy User ID
                        </DropdownMenuItem>
                        <DropdownMenuSeparator />
                        <DropdownMenuItem>View User Details</DropdownMenuItem>


                           <UpdateUserCard id={user.id} initialUsername = {user.userName} initialEmail={user.email}/>

                           <DeleteUserCard id={user.id}/>
                        {/*<DropdownMenuItem className="text-red-600 hover:!bg-red-600 hover:!text-white" onClick={()=>DeleteUser(user.id)}>Delete User</DropdownMenuItem>*/}
                    </DropdownMenuContent>
                </DropdownMenu>
            )
        },

    },
]
