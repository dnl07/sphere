type Props = {
    open: boolean
}

const DropDownArrow = ({ open }: Props) => {
    return (
        <span
            className={`block w-4 h-4 border-t-2  border-l-2 border-black transform transition-all duration-300 -translate-x-1 ${open ? "translate-y-1" : "-translate-y-1"}`}
            style={{
                transform: open
                    ? "rotate(45deg) rotate3d(0, 0, 0, 0deg)"
                    : "rotate(45deg) rotate3d(-90, 90, 0, 180deg)"
            }}
        ></span>
    )
}

export default DropDownArrow;