import { useState } from "react";
import ConfirmDialog from "../../../../shared/components/ConfirmDialog";
import DeleteIcon from "../../../../shared/components/ui/icons/DeleteIcon";
import EditIcon from "../../../../shared/components/ui/icons/EditIcon";

const ItemActions = () => {
    const [showDialog, setShowDialog] = useState<boolean>(false);

    return (
        <>
            <div className="flex flex-row gap-5 mr-1">
                <button className=""><EditIcon color="#000000" strokeWidth={1.5} className="w-7.5 h-7.5 cursor-pointer"/></button>
                <button onClick={() => setShowDialog(true)}><DeleteIcon color="#000000" strokeWidth={1.25} className="w-8 h-8 cursor-pointer" /></button>
            </div>     
            {showDialog && 
                <ConfirmDialog message="Are you sure you want to delete this item?" onConfirm={() => {setShowDialog(false)}} onCancel={() => setShowDialog(false)}/>
            } 
        </>
    );
};

export default ItemActions;