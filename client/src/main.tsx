import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css';
import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import RouteTester from './Pages/RouteTester.tsx';
import UsersDashboard from "@/Pages/Dashboard/UsersDashboard/UsersDashboard.tsx";
import PostsDashboard from "@/Pages/Dashboard/PostsDashboard/PostsDashboard.tsx";
import PostGrid from "@/Pages/Posts/PostGrid.tsx";
import Dashboard from "@/Pages/Dashboard/Dashboard.tsx";
import Authentication from "@/Pages/Users/Authentication.tsx";
import {Provider} from "react-redux";
import {Store} from "./State/Store.ts"
import {LoginRedirect} from "@/Redirects/LoginRedirect.ts";
const loginPaths = ["/login", "/register", "/signin", "/signup"];

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
        path:"/",
        element: <PostGrid/>
      },
      {
        path: "/authentication",
        element : <Authentication/>
      },
      ...loginPaths.map(path => ({
        path,
        element: <LoginRedirect />
      }))
    ]
  },
  {
    path: "/dashboard",
    element: <Dashboard/>,
    children: [
      {
        path: "/dashboard",
        element: <UsersDashboard/>
      },
      {
        path: "/dashboard/posts",
        element: <PostsDashboard/>
      },
      {
        path:"/dashboard/users",
       element: <UsersDashboard/>
      }
  ]}

]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Provider store={Store}>
      <RouterProvider router={router}/>
    </Provider>
  </React.StrictMode>,
)
