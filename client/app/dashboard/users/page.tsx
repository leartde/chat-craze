'use client';
import React, {useEffect, useState} from 'react';
import {columns} from "@/app/dashboard/users/columns";
import {DataTable} from "@/app/dashboard/users/data-table";
type User ={
    id: string;
    userName: string;
    email: string;
}


const Users = () => {
    const [users, setUsers] = useState<User[]>([]);
    useEffect(() => {
        const fetchUsers = async() => {
            const response = await fetch("http://localhost:5002/api/users");
            const data = await response.json();
            setUsers(data);
        };
         fetchUsers();
    }, []);

    console.log("USERS LENGTH ", users.length);
    return (
        <div className="container mx-auto py-10">
            <DataTable columns={columns} data={users}/>
        </div>

    );
};

export default Users;
