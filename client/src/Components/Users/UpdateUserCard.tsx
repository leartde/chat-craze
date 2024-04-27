import React, { useState } from 'react';
import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
    DialogClose
} from "../ui/dialog.tsx";
import { Button } from "../ui/button.tsx";
import { Label } from "../ui/label.tsx";
import { Input } from "../ui/input.tsx";
import UpdateUser from "@/Services/UserServices/UpdateUser.ts";


type UpdateUserCardProps = {
    id: string,
    initialUsername: string,
    initialEmail: string,
}

const UpdateUserCard = ({ id, initialUsername, initialEmail }: UpdateUserCardProps) => {
    const [isOpen, setIsOpen] = useState<boolean>(false);
    const [username, setUsername] = useState<string>(initialUsername);
    const [email, setEmail] = useState<string>(initialEmail);

    const handleUsernameChange = (e: any) => {
        setUsername(e.target.value);
    }

    const handleEmailChange = (e: any) => {
        setEmail(e.target.value);
    }

    const handleSubmit = async (e: any) => {
        e.preventDefault();
        await UpdateUser(id, { UserName: username, Email: email });
        console.log('id: ' + id + ' username: ' + username + ", email: " + email) ;
        setIsOpen(false); // Close the dialog after submission
    }

    return (

        <div>

            <Dialog open={isOpen}  >
                <DialogTrigger  >
                    <Button variant="outline" className="!border-0 !px-2" onClick={() => setIsOpen(true)}>Edit User Details</Button> {/* Open the dialog on button click */}
                </DialogTrigger>
                <DialogContent onPointerDownOutside={()=>setIsOpen(false)}  onEscapeKeyDown={()=>setIsOpen(false)} className="sm:max-w-[425px]">
                    <DialogHeader>
                        <DialogTitle>Edit User Details</DialogTitle>
                        <DialogDescription>
                            Make changes to your user's details here. Click save when you're done.
                        </DialogDescription>
                    </DialogHeader>
                    <div className="grid gap-4 py-4">
                        <div className="grid grid-cols-4 items-center gap-4">
                            <Label htmlFor="username" className="text-right">
                                Username
                            </Label>
                            <Input id="username" onChange={handleUsernameChange} value={username} className="col-span-3" />
                        </div>
                        <div className="grid grid-cols-4 items-center gap-4">
                            <Label htmlFor="email" className="text-right">
                                Email
                            </Label>
                            <Input id="email" value={email} onChange={handleEmailChange} className="col-span-3" />
                        </div>
                    </div>
                    <DialogFooter>
                        <Button type="submit" onClick={handleSubmit}>Save changes</Button>
                    </DialogFooter>
                    <DialogClose asChild>
                        <Button onClick={()=>setIsOpen(false)} type="button" variant="secondary">
                            Close
                        </Button>
                    </DialogClose>
                </DialogContent>
            </Dialog>
        </div>
    );
};

export default UpdateUserCard;
