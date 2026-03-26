type Props = {
    onClick: () => void
}

const Cross = ({ onClick }: Props) => {
    return (
        <button onClick={onClick} className="cursor-pointer">
            <span className="block w-6 h-0.5 bg-black rotate-45" />
            <span className="block w-6 h-0.5 bg-black -rotate-45 -translate-y-0.5" />
        </button>
    );
}

export default Cross;