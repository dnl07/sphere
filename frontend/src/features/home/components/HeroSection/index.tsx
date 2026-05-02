import Sphere from "../../../../shared/components/Sphere";

const HeroSection = () => {

    return (
        <div className="flex-1 flex items-center justify-center flex-col text-center gap-4">
            <Sphere />
            <h1 className="text-4xl font-semibold tracking-tight">Welcome to sphere</h1>
            <h2 className="text-xl text-text-sub w-sm lg:w-md">
                Manage your clothing inventory with advanced tools and intuitive design
            </h2>
        </div>
    );
}

export default HeroSection;