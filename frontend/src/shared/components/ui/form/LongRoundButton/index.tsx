type Props = {
    label: string,
    onClick: () => void
}

const LongRoundButton = ({ label, onClick }: Props) => {

    return (
        <button onClick={onClick} className="bg-gray-950 h-20 px-5 fixed bottom-0 text-white rounded-full">
            <span className="text-xl">{label}</span>
        </button>
    )
}

export default LongRoundButton;