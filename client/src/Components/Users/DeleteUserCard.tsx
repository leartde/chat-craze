import React from 'react';
import {
    AlertDialog, AlertDialogAction, AlertDialogCancel,
    AlertDialogContent, AlertDialogDescription, AlertDialogFooter,
    AlertDialogHeader,
    AlertDialogTitle,
    AlertDialogTrigger
} from "@/Components/ui/alert-dialog.tsx";
import DeleteUser from "@/Services/UserServices/DeleteUser.tsx";
type DeleteProps = {
    id: string
}
const DeleteUserCard =  ({id}: DeleteProps) => {
    return (
        <>
            <AlertDialog>
                <AlertDialogTrigger className="!border-0 !px-2 !text-left rounded-xl !h-full !text-red-600 hover:!bg-red-600 hover:!text-white !w-full">Delete User</AlertDialogTrigger>
                <AlertDialogContent>
                    <AlertDialogHeader>
                        <AlertDialogTitle>Are you sure you want to delete this user?</AlertDialogTitle>
                        <AlertDialogDescription>
                            This action cannot be undone. This will permanently delete this account
                            and remove all their data from our servers.
                        </AlertDialogDescription>
                    </AlertDialogHeader>
                    <AlertDialogFooter>
                        <AlertDialogCancel>Cancel</AlertDialogCancel>
                        <AlertDialogAction onClick={()=> DeleteUser(id)}>Continue</AlertDialogAction>
                    </AlertDialogFooter>
                </AlertDialogContent>
            </AlertDialog>
        </>
    );
};

export default DeleteUserCard;
