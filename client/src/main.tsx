import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css';
import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import RouteTester from './Pages/RouteTester.tsx';
import UsersDashboard from "@/Pages/Dashboard/UsersDashboard/UsersDashboard.tsx";
import PostsDashboard from "@/Pages/Dashboard/PostsDashboard/PostsDashboard.tsx";
import PostGrid from "@/Pages/Posts/PostGrid.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element:<App/>,
    children: [
      {
        path:"/route-tester",
        element: <RouteTester/>
      },
      {
        path:"/dashboard/users",
        element :<UsersDashboard/>
      },
      {
        path:"/dashboard/posts",
        element: <PostsDashboard/>
      },
      {
        path:"/",
        element: <PostGrid/>
      }
    ]
  },
  
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router}/>
  </React.StrictMode>,
)
