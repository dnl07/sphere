type Props = {
    image: File | null
}

const ImageEditor = ({ image }: Props) => {
    return (
        <div className="bg-black w-full h-full fixed z-30 top-0 bottom-0 left-0">
            <button className="bg-white">Back</button>
        </div>
    )
} 

export default ImageEditor;