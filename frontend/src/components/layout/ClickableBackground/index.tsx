type Props = {
    bgColor: string,
    onClick: () => void
}

const ClickableBackground = ({ bgColor, onClick }: Props) => {
    return (
        <div className={`${bgColor} z-30 fixed top-0 left-0 w-full h-full`} onClick={onClick} />
    )
}

export default ClickableBackground;