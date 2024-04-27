import {useEffect, useState} from 'react';
import {columns} from './Columns.tsx';
import {DataTable} from "./Data-table.tsx";
import {FetchUsers, User} from "@/Services/UserServices/FetchUsers.ts";

const UsersDashboard = () => {
    const [users, setUsers] = useState<User[]>([]);
    useEffect(() => {
        const getUsers = async () => {
            const users = await FetchUsers();
            setUsers(users);
        };
        getUsers();
    }, []);

    return (
        <div className="w-3/5  py-10">
            <DataTable columns={columns} data={users}/>
        </div>

    );
};

export default UsersDashboard;