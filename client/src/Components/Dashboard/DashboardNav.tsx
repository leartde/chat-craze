import React from 'react';

const DashboardNav = () => {
    return (
        <div className="bg-gray-800 text-white p-4">
            <ul className="space-y-2">
                <li className="px-4 py-2 hover:bg-gray-700 cursor-pointer">Users</li>
                <li className="px-4 py-2 hover:bg-gray-700 cursor-pointer">Posts</li>
            </ul>
        </div>
    );
};

export default DashboardNav;