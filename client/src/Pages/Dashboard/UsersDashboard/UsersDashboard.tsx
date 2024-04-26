import {useEffect, useState} from 'react';
import {columns} from './Columns.tsx';
import {DataTable} from "./Data-table.tsx";
type User ={
    id: string;
    userName: string;
    email: string;
    role: string;
    avatarUrl : string
}


const UsersDashboard = () => {
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
        <div className="w-3/5  py-10">
            <DataTable columns={columns} data={users}/>
        </div>

    );
};

export default UsersDashboard;