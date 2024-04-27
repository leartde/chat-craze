import AuthenticationComponent from "@/Components/Users/AuthenticationComponent.tsx";

const Authentication = () => {
    return (
        <div className="h-full bg-gray-200">
            <div className="w-1/2 h-[760px] p-6 mt-24 relative flex mx-auto justify-center rounded-lg ">
                <AuthenticationComponent/>
            </div>
        </div>
    );
};

export default Authentication;
