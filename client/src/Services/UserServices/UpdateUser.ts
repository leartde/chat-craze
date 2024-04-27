import axios from "axios";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
type UpdateUserProps = {
    UserName : string;
    Email : string;
}



const UpdateUser = async (id: string, { UserName, Email }: UpdateUserProps) => {
    const FormData: UpdateUserProps = {
        UserName: UserName,
        Email: Email,
    };
      try{
          const response = await axios.put(`http://localhost:5002/api/users/${id}`,
              FormData
          );
          console.log("response", response)
          console.log("Form Data ", FormData)
          if(response.status == 200){
              console.log('User updated successfully');
              toast.success("User updated successfully")
              return;
          }
          else {
                console.log('Error updating user: ', response);
                toast.error("Failed updating user")
          }
      }
      catch (e) {
          console.log('Error updating user: ', e);
          toast.error("Failed updating user")
          return;
      }
}

export default UpdateUser;
