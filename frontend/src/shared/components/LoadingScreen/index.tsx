import LoadingIcon from "../ui/icons/LoadingIcon";

const LoadingScreen = () => {
    return (
        <div className="w-full h-full flex flex-col justify-center items-center">
            <LoadingIcon strokeWidth={2.5}/>
        </div>
    );
}

export default LoadingScreen;