import { useState } from "react";
import Card from "../../../../shared/components/layout/Card";
import Carousel from "../../../../shared/components/ui/Carousel";
import useImageFilters from "../../hooks/useImageFilters";
import { allEditorTools, allFilterTools } from "../../constants/tools";
import { isActionTool, isFilterTool, type FilterControlProps } from "../../constants/types";
import { useBackgroundRemover } from "../../../createItemPage/hooks/useBackgroundRemover";

type Props = {
    imageUrl: string | null;
    file: File | null;
}

const ImageEditor = ({ imageUrl, file }: Props) => {
    const {filters, filterString, updateFilter} = useImageFilters(allFilterTools);
    const  {processImage, loading} = useBackgroundRemover();

    const [currentFile, setCurrentFile] = useState<File | null>(file)
    const [currentImageUrl, setCurrentImageUrl] = useState<string | null>(imageUrl)    

    // mobile
    const [activeKey, setActiveKey] = useState<string>("removal")
    const activeTool = allEditorTools.find(tool => tool.key === activeKey)

    const handleRemoveBackground = async () => {
        console.log("clicked")
        if (!currentFile) return
        const newFile = await processImage(currentFile)
        setCurrentFile(new File([newFile], currentFile.name))
        setCurrentImageUrl(URL.createObjectURL(newFile))
        console.log("processed")

    }

    const renderControl = () => {
        if (!activeTool) return;

        if (isFilterTool(activeTool)) {
            return (
                activeTool.renderControl({
                    value: filters[activeTool.key],
                    onChange: (v) => updateFilter(activeTool.key, v),
                    tool: activeTool
                } as FilterControlProps))
        } else if (isActionTool(activeTool)) {
            return activeTool.renderControl({onAction: handleRemoveBackground})
        }
    }

    return (
        <div className="w-full flex flex-col items-center">
            {loading ?? <div>loading</div>}
            {imageUrl ? 
                <div className="w-full flex justify-center pb-35">
                    <img src={currentImageUrl ?? imageUrl} className="h-full object-contain" style={{ filter: `${filterString}`}}/>
                </div>
            :
                <div className="w-full h-full bg-amber-200 flex justify-center items-center">
                    No image uploaded.
                </div>
            }
            <Card className="fixed bottom-0 max-w-5xl flex flex-col">
                <Carousel>
                    {allEditorTools.map(f => (
                        <div className={`bg-bg-sunken rounded-full p-4 cursor-pointer ${activeKey === f.key ? "border-2" : ""}`} onClick={() => setActiveKey(f.key)}>
                            <f.icon className="w-8"/>
                        </div>
                    ))}
                </Carousel>
                <div key={activeKey} className="w-full my-4">
                    {renderControl()}
                </div>
            </Card>
        </div>
    )
} 

export default ImageEditor;