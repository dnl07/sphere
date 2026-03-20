type Props = {
    icon: string
}

const RoundIconButton = ({ icon }: Props) => {
    return (
        <button className="border-2 border-black h-20 aspect-square rounded-full">
            {icon}
        </button>
    )
}

export default RoundIconButton;