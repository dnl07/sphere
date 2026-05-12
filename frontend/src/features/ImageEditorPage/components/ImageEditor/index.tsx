import { useState } from "react";
import Card from "../../../../shared/components/layout/Card";
import Carousel from "../../../../shared/components/ui/Carousel";
import useImageFilters from "../../hooks/useImageFilters";
import { allFilterTools, toolGroups, type ToolGroupKey } from "../../constants/tools";
import { type ActionTool, type FilterControlProps, type FilterTool } from "../../constants/types";
import { useBackgroundRemover } from "../../../createItemPage/hooks/useBackgroundRemover";
import { useImageCanvas } from "../../hooks/useImageCanvas";
import { useNavigate } from "react-router";
import ProcessableImage from "../ProcessableImage";

type Props = {
    file: File | null;
}

const ImageEditor = ({file}: Props) => {
    const navigate = useNavigate();
    const {previewUrl, applyBlob, toFile} = useImageCanvas(file);
    const {filters, filterString, updateFilter, resetFilters} = useImageFilters(allFilterTools);
    const  {processImage, loading} = useBackgroundRemover();

    const [activeKey, setActiveKey] = useState<ToolGroupKey>("backgroundRemoval")
    const activeTools = toolGroups.find(g => g.key === activeKey)

    const handleRemoveBackground = async () => {
        if (!file) return

        const canvasFile = await toFile(file?.name, filterString);
        if (!canvasFile) return

        const processedFile = await processImage(canvasFile)
        applyBlob(processedFile);
    }

    const renderControl = () => {
        if (!activeTools) return null;

        if (activeTools.type === "filter") {
            return (
                <div>
                    <h2 className="text-xl font-semibold">{activeTools.label}</h2>
                    {activeTools.tools.map(tool => {
                        const filterTool = tool as FilterTool;
                        return filterTool.renderControl({
                            value: filters[filterTool.key],
                            onChange: (v) => updateFilter(filterTool.key, v),
                            tool: filterTool
                        } as FilterControlProps);
                    })}
                </div>
            );
        }

        if (activeTools.type === "action") {
            return (
                <div>
                    <h2 className="text-xl font-semibold">{activeTools.label}</h2>
                    {activeTools.tools.map(tool => {
                        const actionTool = tool as ActionTool;
                        return actionTool.renderControl({ onAction: handleRemoveBackground });
                    })}
                </div>
            );
        }

        return null;
    };

    const onSave = async () => {
        if (!file) return;

        const finalFile = await toFile(file?.name, filterString);
        applyBlob(finalFile);

        navigate("/atelier/clothing", { state: {
            editedFile: finalFile
        }})
    }

    return (
        <div className="w-full flex flex-col gap-4 items-center h-vh overflow-hidden">
            <div className="w-full flex justify-end">
                <div className="flex gap-2">
                    <button 
                        className="border border-black justify-end items-end py-1 px-4 rounded-xl whitespace-nowrap cursor-pointer"
                        onClick={() => {resetFilters(); setActiveKey(activeKey)}}
                    >
                        Reset
                    </button>
                    <button 
                        className="bg-black text-white justify-end items-end py-1 px-4 rounded-xl whitespace-nowrap cursor-pointer"
                        onClick={onSave}
                    >
                        Apply
                    </button>
                </div>
            </div>
            <div className="flex-1 min-h-0 flex items-center justify-center overflow-hidden">
                {previewUrl ? (
                    <ProcessableImage url={previewUrl ?? ""} filterString={filterString} isLoading={loading} />
                ) : (
                    <div className="w-full h-full flex justify-center items-center">
                        No image uploaded.
                    </div>                    
                )}
            </div>
            <Card className="flex flex-col mb-4">
                <Carousel>
                    {toolGroups.map(g => (
                        <div className={`bg-bg rounded-full p-4 cursor-pointer ${activeKey === g.key ? "bg-black" : ""}`} onClick={() => setActiveKey(g.key)}>
                            <g.icon />
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

/*


*/

export default ImageEditor;