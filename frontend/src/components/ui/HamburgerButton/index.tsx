type Props = {
    open: boolean;
    onClick: () => void;
}

const HamburgerButton = ({ open, onClick }: Props) => {
    return (
        <button onClick={onClick} aria-label="Menu" className="flex flex-col justify-center gap-1.5 p-1 z-50">
            <span className={`block w-6 h-0.5 bg-gray-800 transition-all duration-300 ${open ? "translate-y-2 rotate-45" : ""}`} />
            <span className={`block w-6 h-0.5 bg-gray-800 transition-all duration-300 ${open ? "opacity-0 scale-x-0" : ""}`} />
            <span className={`block w-6 h-0.5 bg-gray-800 transition-all duration-300 ${open ? "-translate-y-2 -rotate-45" : ""}`} />
        </button>
    );
}

export default HamburgerButton;